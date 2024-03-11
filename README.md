# Console Service Tool (C.S.T) #


### OVERVIEW ###
Console Service Tool (C.S.T.) is a W.I.P comprehensive tool designed to assist users in diagnosing and servicing their gaming consoles. With a focus on PlayStation (PS3, PS4, PS5) and Nintendo Switch, C.S.T. aims to consolidate various diagnostic and service tools into a single, user-friendly platform.


PS5 NOR Patching Kinda Added - I mean dont use if you dont know what you are doing.
NOR Patching Tested and confirmed working.

Please note: 
MAC Address, WiFi Address, Serial, Board Serial are all married. You have to have matching set.

Console Type, IDU are not and can be changed without issues. 

What patches work. Serial Number, Motherboard Serial, Console Type (Disk, or Digital), Board ID and MAC Address. 

Some things to note: 
Will be adding an update notice or auto updater to keep the exe updated when needed. 
Will add a submit your solution this will help further progress on repairing consoles. 
Will be adding a Possible Solutions to the error codes as time goes on.

## Screenshots
New Interface
![image](https://github.com/amoamare/Console-Service-Tool/assets/15149902/846ef2da-21c7-4d4d-a3d5-21f862e01456)

![image](https://github.com/amoamare/Console-Service-Tool/assets/15149902/47edbeff-d932-4eca-86d0-129314bfaf68)

PlayStation 5 NOR Interface.
![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/d5b20998-c0ea-4e0d-8a4d-b8f7309961e3)

PlayStation 5 UART Interface.
![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/962053bb-006c-4e6f-9a43-4ad768334d87)

Example showing no line response and no highlighting. 
![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/7a338443-1666-4a01-b734-53cc38b84784)

Example just showing line response. This is the raw line received from the PlayStation 5.
![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/0570b58e-fd9c-4c13-9930-7915aa127305)

Example showing both line response and hightlighting severe errors.
![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/3d4e5a81-11ed-4d03-8329-1fb33608355c)

Example of a reference image for error code. 
![image](https://github.com/amoamare/ConsoleServiceTool/assets/15149902/d9863882-3615-4b21-99c1-c32cb557cbad)

## FAQ
#### Q: Windows keeps removing the program after installer how do I keep it from doing that?
                
#### Method 1
+ Click start -> type Windows Security -> Click to open.
    + Click Virus & threat protection.
       + Virus & threat protection settings.
           + Manage settings.
              + Exclusions.
                + Add or remove exclusions.
                + Click  Yes on windows security.
                + Add an exclusions.
				+ On folder line paste %userprofile%\AppData\Local\ConsoleServiceTool click select folder.
				
#### Method 2
 + Click start - > type cmd.
 + Right click run as administrator.
 + Click Yes on windows security.
 + copy powershell Add-MpPreference -ExclusionPath "$env:USERPROFILE\AppData\Local\ConsoleServiceTool"
 + Paste into command prompt by right clicking once.
 + Press enter.

#### Q: Why does CST show more than 10 error codes?
A: CST shows all error codes until the response No Error Codes comes from the console. 
The reason to do this is to give the user a better and clear idea of what may originally 
happend. Its easy for an end user to fill all 10 previous error slots with just a couple of
codes such as, APU halt or freeze, Unxpected shut down etc.
				
#### Q: Can I used this tool to read UART codes from a PS5?

A: Yes! Download and run the tool select Playstation 5 tab > UART Tools and Operation Read Codes. You must be connected via UART to read codes from the Playstation 5.

#### Q: I Keep getting "Operation Cancelled" do you know why?

A: Short answer if everything is connected properly, then you possibly have a dead southbridge as the southbridge is required to function for UART to work.

A: Long answer, Check Trouble shooting.

#### Q: I need to convert my disk drive console to digital. Can this tool do that?

A: Yes! Open CST under PlayStation 5 NOR tools, select browse and open your disk drive console's NOR dump. 
Change from Disk to Digtal then save your patched NOR. Flash the patched NOR back to your console. Your console 
will now boot as digital.

#### Q: Do I need a digital NOR dump to convert my disk drive console to digital?
A: No. You can dump your NOR from your console directly and change it to digital
using this tool. 

## Hardware Recommended
UART Interface 3.3v
For ease of use recommend the USB to TTL found here: https://www.amazon.com/gp/product/B0B1HYCN34/ref=ppx_yo_dt_b_search_asin_image?ie=UTF8&psc=1
If you buy a CH341 make sure to get one that has a switch from 5v to 3.3v otherwise you will need to mod it for 3.3v. 


## Trouble Shooting
* Operation Cancelled - this occurs either because of user cancelled the operation or a time out has occurred waiting for response from the console. 
    1. Verify have a TTL, CH341 or other similar device that runs at 3.3v important! and that the correct drivers have been installed. If drivers have been installed, make sure they are not pending a restart. If you are unsure. Restart your computer. 
    2. Go to device manager -> start devmgmt. Check under Serial ports and verify that a serial port is listed. Unplug your TTL/CH341 and see if it disappears. If it does. Replug the device in and check what COMPORT it is assigned to. 
    3. Check that your TX,RX and GND are securely connected to your console.
    4. Check that the console is plugged into a powered wall outlet. The ps5 does not need to be powered on but does need to have powered supplied to it. 
    5. Click read codes. If you still get Operation Cancelled. Try swapping your TX and RX wires.
    6. Check fuse F7003 if blown UART will not respond.
    7. Check NOR - Bad or Currupted NOR will prevent UART.
    8. Still getting Operation Cancelled. Switch the software to "Monitor" mode and connect. This mode will listen for anything the PS5 will say. Unplug the PS5 and wait 5 secs. Reconnect power to the PS5 and check that the PS5 has given signal to the software. If you still do not see anything from the PS5 and you swapped your TX and RX try swapping them back and repeat the steps. If still no response from the console. Try a known good console to rule out a hardware / software issue. If that works. Your console that did not respond has a dead southbridge.

## Fuse Information and Information (EDM-002)
F5401 - No UART errors when pulled - console still boots normally.

F5402 - Disk Drive, No UART errors displayed. - console still boots normally.

F7502 - Storage Controller - Following codes will display.

    1. 80810001
    2. C0160203
    3. C0160303 

F7003 - No UART errors when pulled - console still boots normally. 

F7501 - External M.2 Storage No UART errors displayed. If no M.2 storage detected Check Fuse and 3.3v regulator.

F3502 - Pending - No UART errors displayed.

NOR - Bad / Currupted / Missing - No UART response. 3 quick beeps off.

Fuses can have continuity but fail under load. Simply checking continuity doesn't guaranteed fuse is good.


## Some tips while using UART
UART Codes can be thrown from standby or power on state. 
I recommend you first read and save any codes your PS5 has thrown. After that be sure to clear the errlog.
Unplug the PS5 from the wall and wait 5 seconds. 
Plug the PS5 back into the wall DO NOT POWER ON THE PS5, wait 10 seconds for standby to initialize.
Read error codes. If you have error codes. These are most likely related to standby issues. Fix them first. 
Once you have no error codes in standby.
Click the power button only 1 time. 
Read codes - after you have read the codes. Fix these issues. These should mostly be related to power on, so don't spend much time focusing on standby rails.
Check things related to powering on the console. Enable pins etc. 


## Support

If you have to have support and updated codes right away. Free software isn't the answer for you. This software only reads the code much like a OBDII reader for your car. The codes this software has come from the https://www.psdevwiki.com/ps5/history/Southbridge_Error_Codes and private Pastebin dumps. Its up to the community to add/update or remove code information. The Console itself displays the error code. Its up to the end users to figure out what that means and update the list. If you cannot wait for the community then check out BwE's or Andy_maN's software which is paid software with support.

BwE - PS5 Code Reader - [GitHub](https://github.com/BetterWayElectronics/ps5-code-reader)

BwE - PS5 Nor Tools - [GitHub](https://github.com/BetterWayElectronics/ps5-nor-tool)

Andy_maN - [GitHub](https://github.com/andy-man/ps5-wee-tools)

## Contributors
### People who provided information, value feedback, support or where information was gathered from.

RustyRaindeer - [GitHub](https://github.com/RustyRaindeer) - for added functionality and given me some ideas. 

UART Images Provided
User: [stetofix](https://gbatemp.net/members/stetofix.670642/) [Images](https://gbatemp.net/threads/ps5-uart-commands.642741/page-3)

GsmHack4you

dan2wik

SterHawk


### A Project in works by [Fix MY](https://www.utah.repair)
https://www.utah.repair

In Utah? Looking for a repair on your console? Reach out to Fix MY! 

## Want to help or contribute?
We are looking for donor boards to further this project.
Send email: amoamare+cst@gmail.com

