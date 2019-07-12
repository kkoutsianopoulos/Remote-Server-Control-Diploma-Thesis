`timescale 1ns / 1ps

////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer:
//
// Create Date:   15:57:17 03/23/2019
// Design Name:   Input_Stage
// Module Name:   /home/kkoutsianopoulos/Documents/ise_projects/ADV_Capture_1/ADV_Capture/Input_Stage_test.v
// Project Name:  ADV_Capture
// Target Device:  
// Tool versions:  
// Description: 
//
// Verilog Test Fixture created by ISE for module: Input_Stage
//
// Dependencies:
// 
// Revision:
// Revision 0.01 - File Created
// Additional Comments:
// 
////////////////////////////////////////////////////////////////////////////////

module Input_Stage_test;

	// Inputs
	reg rst_n;
	reg [15:0] Pixel_Bus;
	reg HS;
	reg VS;
	reg DE;
	reg LLC;

	// Outputs
	wire [31:0] data;
	wire [20:0] counter;

	// Instantiate the Unit Under Test (UUT)
	Input_Stage uut (
		.rst_n(rst_n), 
		.Pixel_Bus(Pixel_Bus), 
		.HS(HS), 
		.VS(VS), 
		.DE(DE), 
		.LLC(LLC), 
		.data(data), 
		.counter(counter)
	);

	initial begin
		// Initialize Inputs
		rst_n = 1;
		Pixel_Bus = 0;
		HS = 0;
		VS = 0;
		DE = 0;
		LLC = 0;

		// Wait 100 ns for global reset to finish
		#100;
      rst_n = 0;
		// Add stimulus here
      #100;
		rst_n = 1;
		#120;
		VS = 1;
		#4000;
		DE = 1;
		#25600;
		DE = 0;
		#4000;
		VS = 0;
	end
    
	 always #20 LLC =~LLC;
	 
endmodule

