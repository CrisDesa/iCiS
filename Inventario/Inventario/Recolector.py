import wmi
class RecoWin:

    ''' Obtiene los datos de cada equipo en la lista de computadoras'''
    
    
    def __init__(self):
        self.computers = computers

    def obtener_datos(self,computers):
      
        datos_todo = {}
        
        for compu in computers:
            computer = wmi.WMI(compu)
            datos = {}
            datos["nombre"] = compu
            for caracteristica in computer.Win32_OperatingSystem():
                datos["SO_version"] = (caracteristica.Caption)
                datos["SO_SP"] = (caracteristica.CSDVersion)
        
            for caracteristica in computer.Win32_computersystem():
                datos["Dominio"] = caracteristica.Domain
                datos["Marca"] = caracteristica.Manufacturer
                datos["Modelo"] = caracteristica.Model

            datos_todo[compu] = datos
        return datos_todo


def volcar_datos (todos_servidores):
    compu={}
    for compu in todos_servidores:
        print(compu)
        for caracteristica in todos_servidores[compu]:
            salida = '{}: {}'.format(caracteristica, todos_servidores[compu][caracteristica])
            print(salida)
    return salida

computers = ('P522881',)
volcar_datos(todos_servidores = RecoWin().obtener_datos(computers))


