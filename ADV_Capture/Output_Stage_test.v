`timescale 1ns / 1ps

////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer:
//
// Create Date:   17:49:05 03/23/2019
// Design Name:   Output_Stage
// Module Name:   /home/kkoutsianopoulos/Documents/ise_projects/ADV_Capture_1/ADV_Capture/Output_Stage_test.v
// Project Name:  ADV_Capture
// Target Device:  
// Tool versions:  
// Description: 
//
// Verilog Test Fixture created by ISE for module: Output_Stage
//
// Dependencies:
// 
// Revision:
// Revision 0.01 - File Created
// Additional Comments:
// 
////////////////////////////////////////////////////////////////////////////////

module Output_Stage_test;

	// Inputs
	reg rst_n;
	reg CLK;
	reg txe_n;
	reg [31:0] data_in;
	reg [20:0] counter;

	// Outputs
	wire [31:0] data;
	wire [3:0] be;
	wire wr_n;

	// Instantiate the Unit Under Test (UUT)
	Output_Stage uut (
		.rst_n(rst_n), 
		.CLK(CLK), 
		.txe_n(txe_n), 
		.data_in(data_in), 
		.counter(counter), 
		.data(data), 
		.be(be), 
		.wr_n(wr_n)
	);

	initial begin
		// Initialize Inputs
		rst_n = 1;
		CLK = 0;
		txe_n = 1;
		data_in = 0;
		counter = 0;

		// Wait 100 ns for global reset to finish
		#100;
       rst_n = 1'b0;
		 #100;
		 rst_n = 1'b1;
		 #100;
		// Add stimulus here
	
	end
   
	always #7 CLK =~CLK;
	
	
endmodule

