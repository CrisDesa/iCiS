
import wmi

computer = wmi.WMI('P522881')
for os in computer.Win32_OperatingSystem():
    print(os.Caption)





