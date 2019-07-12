`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date:    17:22:40 03/22/2019 
// Design Name: 
// Module Name:    Internal_FIFO 
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
/// This module is a FIFO with 10 cessl 32 bit wide ///
/// flag is an output variable indicacating when     ///
/// fifo has data to be read                                     ///
/// flag is active high. If low no read must be take///
/// place
module Internal_FIFO(
	 input rst_n,
    input clk1,
    input [31:0] data_in,
    input wr,
    input clk2,
    input rd,
    output flag,
    output reg [31:0] data_out
    );
	
	//internal fifo memory allocation
	reg  [31:0] memory[9:0];
	reg [3:0] counter;
	
	always @ (negedge clk1 or negedge rst_n)
	begin
		if(!rst_n) begin
			counter <= 4'b0000;
			memory[0] <= 32'h00000000;
			memory[1] <= 32'h00000000;
			memory[2] <= 32'h00000000;
			memory[3] <= 32'h00000000;
			memory[4] <= 32'h00000000;
			memory[5] <= 32'h00000000;
			memory[6] <= 32'h00000000;
			memory[7] <= 32'h00000000;
			memory[8] <= 32'h00000000;
			memory[9] <= 32'h00000000;
			flag <= 0;
		end
		else begin
			if(wr) begin
				memory[counter] <= data_in;
				counter <= counter + 1'b1;
			end
		end
	end
	
	
	

endmodule
