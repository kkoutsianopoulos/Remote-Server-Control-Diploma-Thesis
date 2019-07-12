`timescale 1ns / 1ps

////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer:
//
// Create Date:   18:11:47 03/23/2019
// Design Name:   ADV_Capture
// Module Name:   /home/kkoutsianopoulos/Documents/ise_projects/ADV_Capture_1/ADV_Capture/ADV_Capture_test.v
// Project Name:  ADV_Capture
// Target Device:  
// Tool versions:  
// Description: 
//
// Verilog Test Fixture created by ISE for module: ADV_Capture
//
// Dependencies:
// 
// Revision:
// Revision 0.01 - File Created
// Additional Comments:
// 
////////////////////////////////////////////////////////////////////////////////

module ADV_Capture_test;

	// Inputs
	reg rst_n;
	reg [15:0] Pixel_Bus;
	reg HS;
	reg VS;
	reg DE;
	reg LLC;
	reg CLK;
	reg txe_n;

	// Outputs
	wire [31:0] data;
	wire [3:0] be;
	wire wr_n;

	// Instantiate the Unit Under Test (UUT)
	ADV_Capture uut (
		.rst_n(rst_n), 
		.Pixel_Bus(Pixel_Bus), 
		.HS(HS), 
		.VS(VS), 
		.DE(DE), 
		.LLC(LLC), 
		.CLK(CLK), 
		.txe_n(txe_n), 
		.data(data), 
		.be(be), 
		.wr_n(wr_n)
	);
	reg [21:0] cnt;
	initial begin
		// Initialize Inputs
		rst_n = 1;
		Pixel_Bus = 0;
		HS = 0;
		VS = 0;
		DE = 0;
		LLC = 0;
		CLK = 0;
		txe_n = 1;

		// Wait 100 ns for global reset to finish
		#100;
      rst_n = 0;
		#100;
		rst_n = 1;
		txe_n = 0;
		// Add stimulus here
		#120;
		VS = 1;
		#4000;
		DE = 1;
		#25600;
		DE = 0;
		#4000;
		VS = 0;
		
	end
	
	always #20 LLC=~LLC;
	always @ (negedge LLC)
	begin
		Pixel_Bus <= Pixel_Bus + 1'b1;
	end
	
	always #7 CLK=~CLK;
   always @ (negedge CLK)
	begin
		if(!rst_n)
		begin
			cnt <= 0;
		end
		else
		begin
			if(cnt == 100)
			begin
				txe_n <= 1;
				cnt <= cnt + 1;
			end
			else if(cnt == 120)
				begin
					txe_n <= 0;
					cnt <= 0;
				end
			else 
				cnt <= cnt + 1;
		end
	end
endmodule

