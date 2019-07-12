`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date:    17:16:41 03/22/2019 
// Design Name: 
// Module Name:    ADV_Capture 
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
module ADV_Capture(
    input rst_n,
    input [15:0] Pixel_Bus,
    input HS,
    input VS,
    input DE,
    input LLC,
    input CLK_I, ///allagmeno
    input txe_n,
    output [31:0] data,
    output [3:0] be,
    output wr_n
    );

	wire [31:0] data_internal;
	wire [20:0] counter_internal;
	wire CLK;
	IBUFG #(
		.IOSTANDARD("DEFAULT")
	) IBUFG_inst (
		.O(CLK),
		.I(CLK_I)
	);

	
	Input_Stage u1(
		.rst_n(rst_n),
		//.HS(HS),
		.VS(VS),
		.DE(DE),
		.LLC(LLC),
		.Pixel_Bus(Pixel_Bus),
		.data(data_internal),
		.counter(counter_internal)
		);
	
	Output_Stage u2(
		.rst_n(rst_n),
		.CLK(CLK),
		.txe_n(txe_n),
		.wr_n(wr_n),
		.data(data),
		.be(be),
		.data_in(data_internal),
		.counter(counter_internal)
		);

endmodule
