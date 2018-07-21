import wmi

class RecoWin:
    '''Obtiene los datos de cada equipo en la lista de computadoras con sistema operativo Windows'''
        
    def __init__(self,lista_computers):
        self.computers = lista_computers

    def capturar_datos(self):
        '''Realiza consulta WMI y las almacena en un diccionario con los nombres de las características como paramteros
           con un control de fallo de conexion'''
        
        datos_todo = {}  #limpia diccionario donde carga datos del equipo
        
        for compu in self.computers:
            datos = {}
            try: 
                computer = wmi.WMI(compu)
            except:
                datos["conexion"] = False
            else:
                datos["nombre"] = compu
                datos["conexion"] = True 
            
                for caracteristica in computer.Win32_OperatingSystem():
                    datos["SO_version"] = (caracteristica.Caption)
                    datos["SO_SP"] = (caracteristica.CSDVersion)
        
                for caracteristica in computer.Win32_computersystem():
                    datos["Dominio"] = caracteristica.Domain
                    datos["Marca"] = caracteristica.Manufacturer
                    datos["Modelo"] = caracteristica.Model

            datos_todo[compu] = datos

        return datos_todo


def volcar_datos (datos_servidores):
    compu={}
    for compu in datos_servidores:
        print('')
        print(compu)
        for caracteristica in datos_servidores[compu]:
            salida = '{}: {}'.format(caracteristica, datos_servidores[compu][caracteristica])
            print(salida)

    return salida

computers = ('Error_1','P522881','stbuetmadm07',)
volcar_datos(RecoWin(computers).capturar_datos())


                                          