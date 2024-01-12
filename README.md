# Console Service Tool (C.S.T) #


### What C.S.T Is ###
Overview
Console Service Tool (C.S.T.) is a W.I.P comprehensive tool designed to assist users in diagnosing and servicing their gaming consoles. With a focus on PlayStation (PS3, PS4, PS5) and Nintendo Switch, C.S.T. aims to consolidate various diagnostic and service tools into a single, user-friendly platform.


PS5 NOR Patching Kinda Added - I mean dont use if you dont know what you are doing. In theory it patches fine. I dont have a PS5 to test ATM. 
What patches work. Serial Number, Motherboard Serial, Console Type (Disk, or Digital), Board ID and MAC Address. 
## Screenshots

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/29c901a4-5217-4c65-81cf-ea83caf73bd3)

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/d5b20998-c0ea-4e0d-8a4d-b8f7309961e3)

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/31aefa1f-9def-4d09-af97-67c888e1f906)


## License



## FAQ

#### Q: Can I used this tool to read UART codes from a PS5?

A: Yes! Download and run the tool select Playstation 5 tab > UART Tools and Operation Read Codes. You must be connected via UART to read codes from the Playstation 5.

#### Q: I Keep getting "Operation Cancelled" do you know why?

A: Short answer if everything is connected properly, then you possibly have a dead southbridge as the southbridge is required to function for UART to work.

A: Long answer, Check Trouble shooting.




## Trouble Shooting
* Operation Cancelled - this occurs either because of user cancelled the operation or a time out has occured waiting for response from the console. 
    1. Verify  have a TTL, CH341 or other similar device and that the correct drivers have been installed. If drivers have been installed make sure they are not pending a restart. If you are unsure. Restart your computer. 
    2. Go to device manager -> start devmgmt. Check under Serial ports and verify that a serial port is listed. Unplug your TTL/CH341 and see if it disapears. If it does. Replug the device in and check what COMPORT it is assinged to. 
    3. Check that your TX,RX and GND are securely connected to your console.
    4. Check that the console is plugged into a powered wall outlet. The ps5 does not need to be powered on but does need to have powere supplied to it. 
    5. Click read codes. If you still get Operation Cancelled. Try swapping your TX and RX wires. 
    6. Still getting Operation Canclled. Switch the software to "Monitor" mode and connect. This mode will listen for anything the PS5 will say. Unplug the PS5 and wait 5 secs. Reconnect power to the PS5 and check that the PS5 has given signal to the software. If you still do not see anything from the PS5 and you swapped your TX and RX try swapping them back and repeat the steps. If still no response from the console. Try a known good consol to rule out a hardware / software issue. If that works. Your console that did not respond has a dead southbridge.