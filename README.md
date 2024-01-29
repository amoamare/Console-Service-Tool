# Console Service Tool (C.S.T) #


### What C.S.T Is ###
Overview
Console Service Tool (C.S.T.) is a W.I.P comprehensive tool designed to assist users in diagnosing and servicing their gaming consoles. With a focus on PlayStation (PS3, PS4, PS5) and Nintendo Switch, C.S.T. aims to consolidate various diagnostic and service tools into a single, user-friendly platform.


PS5 NOR Patching Kinda Added - I mean dont use if you dont know what you are doing. In theory it patches fine. I dont have a PS5 to test ATM. 
What patches work. Serial Number, Motherboard Serial, Console Type (Disk, or Digital), Board ID and MAC Address. 
## Screenshots

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/d5b20998-c0ea-4e0d-8a4d-b8f7309961e3)

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/31aefa1f-9def-4d09-af97-67c888e1f906)

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/7a338443-1666-4a01-b734-53cc38b84784)

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/0570b58e-fd9c-4c13-9930-7915aa127305)

![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/3d4e5a81-11ed-4d03-8329-1fb33608355c)

Example of a reference image for error code. 
![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/d9863882-3615-4b21-99c1-c32cb557cbad)



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

## Support

If you have to have support and updated codes right away. Free software isn't the answer for you. This software only reads the code much like a OBDII reader for your car. The codes this software has came from the https://www.psdevwiki.com/ps5/history/Southbridge_Error_Codes and private pastebin dumps. Its up to the community to add/update or remove code information. The Console itself displays the error code. Its up to the end users to figure out what that means and update the list. If you can not wait for the community then check out BwE's or Andy_maN's software which is paid software with support.

BwE - PS5 Code Reader - https://github.com/BetterWayElectronics/ps5-code-reader

BwE - PS5 Nor Tools - https://github.com/BetterWayElectronics/ps5-nor-tool

Andy_maN - https://github.com/andy-man/ps5-wee-tools
