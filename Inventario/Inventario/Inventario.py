
import wmi

computers = ('P522881','P522881')

for compu in computers:
    computer = wmi.WMI(computer)
    for os in computer.Win32_OperatingSystem():
        print(os)
    for os in computer.Win32_computersystem():
        print(os)





