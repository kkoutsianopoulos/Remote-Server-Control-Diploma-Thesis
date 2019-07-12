`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date:    17:21:07 03/22/2019 
// Design Name: 
// Module Name:    Output_Stage 
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
module Output_Stage(
	 input rst_n,
    input CLK,
    input txe_n,
    input [31:0] data_in,
    input [20:0] counter,
    output reg [31:0] data,
    output reg [3:0] be,
    output reg wr_n
    );
	 
	 //internal fifo structure for storing 32 bit pixels until ready to be sent out
	 reg [31:0] internal_fifo [39:0];
	 reg [5:0] internal_fifo_counter;
	 
	//variables to keep track of changes on te counter
	reg [20:0] counter_1;
	reg [20:0] counter_2;
	

	always @ (posedge CLK or negedge rst_n)
	begin
		if(!rst_n) begin
			internal_fifo[0] <= 32'h00000000;
			internal_fifo[1] <= 32'h00000000;
			internal_fifo[2] <= 32'h00000000;
			internal_fifo[3] <= 32'h00000000;
			internal_fifo[4] <= 32'h00000000;
			internal_fifo[5] <= 32'h00000000;
			internal_fifo[6] <= 32'h00000000;
			internal_fifo[7] <= 32'h00000000;
			internal_fifo[8] <= 32'h00000000;
			internal_fifo[9] <= 32'h00000000;
			internal_fifo_counter <= 4'b000000;
			counter_1 <= 21'b000000000000000000000;
			counter_2 <= 21'b000000000000000000000;
			wr_n <= 1'b1;
			data <= 32'hffffffff;
			be <= 4'b1111;
		end
		else begin
			counter_1 <= counter;
			counter_2 <= counter_1;
			
			//give priority to read from adv
			if(wr_n == 1'b0)
				wr_n <= 1'b1;
			if(counter_1 != counter_2) begin
				internal_fifo[internal_fifo_counter] <= data_in;
				internal_fifo_counter <= internal_fifo_counter + 1'b1;
			end
			else begin
				if(internal_fifo_counter != 0) begin
					if(txe_n == 1'b0) begin	
						if(wr_n == 1'b1) begin
							wr_n <= 1'b0;
							data <= internal_fifo[0];
							internal_fifo_counter <= internal_fifo_counter - 1'b1;
							//shift fifo data one step to the start of the fifo
							// in this way the first value that came in can be accessed in the first 
							// position of the fifo with index 0
							internal_fifo[0] <= internal_fifo[1];
							internal_fifo[1] <= internal_fifo[2];
							internal_fifo[2] <= internal_fifo[3];
							internal_fifo[3] <= internal_fifo[4];
							internal_fifo[4] <= internal_fifo[5];
							internal_fifo[5] <= internal_fifo[6];
							internal_fifo[6] <= internal_fifo[7];
							internal_fifo[7] <= internal_fifo[8];
							internal_fifo[8] <= internal_fifo[9];
							//check for the end of frame sequence
							if(internal_fifo[internal_fifo_counter - 1'b1] == 32'h00000055) 
								be <= 4'b0001;
							else
								be <= 4'b1111;
						end
						else 
							wr_n <= 1'b1;
					end
				end
				if(wr_n == 1'b0)
					wr_n <= 1'b1;
			end
		end
	end
	 


endmodule
