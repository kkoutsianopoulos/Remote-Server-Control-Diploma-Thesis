`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date:    17:18:56 03/22/2019 
// Design Name: 
// Module Name:    Input_Stage 
// Project Name: 
// Target Devices: 
// Tool versions: 
// Description: 
//
// Dependencies: 
//
// Revision: 
// Revision 0.01 - File Created
// Additional Comments: 
//
//////////////////////////////////////////////////////////////////////////////////
module Input_Stage(
    input rst_n,
    input [15:0] Pixel_Bus,
    //input HS,
    input VS,
    input DE,
    input LLC,
    output reg [31:0] data,
    output reg [20:0] counter
    );
	 
	 reg flag;
	 reg vs_1;
	 reg vs_2;
	 
	 always @ (posedge LLC or negedge rst_n)
	 begin
		if(!rst_n) 
		begin
			counter <= 21'b000000000000000000000;
			data <= 32'hffffffff;
			flag <= 1'b0;
		end
		else begin
			vs_1 <= VS;
			vs_2 <= vs_1;
			/// recognize the start of the frame when vs goes high
			if(vs_2 == 1'b0 && vs_1 == 1'b1)  begin
				if(counter == 21'b000000000000000000000) begin
					data <= 32'h0000820C;
					counter <= counter +1'b1;
				end
			end
			//frame is still active
			if(vs_1 ==1'b1) begin
				// we must write the remaining 2 frame start codes before the DE 
				// goes high in the frame
				if(!DE) begin
					if(counter == 21'b00000000000000000001) begin
						data <= 32'hBABEFACE;
						counter <= counter + 1'b1;
					end
					else if(counter == 21'b00000000000000000010) begin
						data <= 32'hBABEFACE;
						counter <= counter + 1'b1;
					end
				end
				//DE is high and the pixel counter is greater than 2 so we start to read and
				//write pixels
				else begin
					// we pack 2 16 bit pixels in a 32 bit wide value so a flag is needed
					// to indicate if we are on the first 16 bits or on the last 16 bits of the sequence
					if(flag == 1'b0) begin
						data[15:8] <= Pixel_Bus[7:0];
						data[7:0] <= Pixel_Bus[15:8];
						flag <= 1'b1;
					end
					else begin
						data[31:24] <= Pixel_Bus[7:0];
						data[23:16] <= Pixel_Bus[15:8];
						flag <= 1'b0;
						counter <= counter + 1'b1;
					end
				end
			end
			// recognize the end of the frame and write the proper code to the output
			if(vs_2 == 1'b1 && vs_1 == 1'b0)  begin
				data <= 32'h00000055;
				counter <= counter <= 21'b000000000000000000000;
			end
		end
	 end

endmodule
