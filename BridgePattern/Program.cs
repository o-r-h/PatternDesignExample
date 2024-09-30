// See https://aka.ms/new-console-template for more information

/**Generally speaking, you can extend such an app in two independent directions:

Have several different GUIs (for instance, tailored for regular customers or admins).
Support several different APIs (for example, to be able to launch the app under Windows, Linux, and macOS).**/

using BridgePattern.Classes;

SonyRemoteControl sonyRemoteControl = new SonyRemoteControl(new SonyLedTv());
sonyRemoteControl.SwitchOn();
sonyRemoteControl.SetChannel(101);
sonyRemoteControl.SwitchOff();

Console.WriteLine();
SamsungRemoteControl samsungRemoteControl = new SamsungRemoteControl(new SamsungLedTv());
samsungRemoteControl.SwitchOn();
samsungRemoteControl.SetChannel(202);
samsungRemoteControl.SwitchOff();




Console.ReadKey();
