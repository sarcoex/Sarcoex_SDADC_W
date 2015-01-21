# Sarcoex_SDADC_W
Sarcoex's Simple Default Audio Device Changer for Windows

1 DESCRIPTION

Sarcoex's Simple Default Audio Device Changer for Windows is a simple software to easy change the default sound device (playback).
It's preconfigured with the prefixes "Headset", "TV" and "Speakers". 

For best use you should rename your sound devices (playback) to the configured prefixes.

Example:

My Logitech G930 Headset was automatically named as "Speakers" in the sound device settings, so I simply changed it to "Headset".
I renamed my NVIDIA High Definition Audio device to "TV", as I have connected my Geforce card to an HD TV.
I have connected my speakers to a Realtek High Definition Audio device on the back of my motherboard and named the device simply as "Speakers".

So in conclusion
"Logitech G930"->"Headset"
"NVIDIA High Definition Audio"->"TV"
"Realtek High Definition Audio"->"Speakers"


2 HOW TO USE THIS SOFTWARE

1. Start the software with start.bat
2. Just click on the button which has the icon of the device you want to switch to.


3 EDITING THE CONFIG FILE

If you for any reason you don't want (or can't) rename playback audio devices, you can edit the prefixed names in the config file instead.

Just open the file "Sarcoex_SDADC_W.exe.config" with Notepad or similar text editor software (I personally prefer Notepad++, with the "monstreous" icon).
Look for the section "<applicationSettings>"->"<Sarcoex_SDADC_W.Properties.Settings>"
There you find some settings which follows this syntax:
<setting name="{DeviceNameVariable}" serializeAs="String">
	<value>{NameOfTheDevice}</value>
</setting>

It's very important that you only changes the value between the <value> tag.
Example:
<setting name="HeadsetDevice" serializeAs="String">
	<value>Logitech G930</value>
</setting>