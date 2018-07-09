
import wmi

computers = ('P522881','P522881')

def obtener_datos(computers=('localhost')):
    ''' Obtiene los datos de cada equipo en la lista de computadoras'''
    datos_todo = {}

    for compu in computers:
        computer = wmi.WMI(compu)
        datos = {}

        datos["nombre"] = compu

        for os in computer.Win32_OperatingSystem():
            datos["SO_version"] = (os.Caption)
            datos["SO_SP"] = (os.CSDVersion)
        
        for os in computer.Win32_computersystem():
            datos["Dominio"] = os.Domain
            datos["Marca"] = os.Manufacturer
            datos["Modelo"] = os.Model

        datos_todo[compu] = datos
    return datos_todo

def 

todos_servidores = obtener_datos(computers)
compu={}
for compu in todos_servidores:
    for caracteristica in todos_servidores[compu]:
        salida = '{}: {}'.format(caracteristica, todos_servidores[compu][caracteristica])
        print(salida)


