# Chronos Arena — versión fusionada

Esta carpeta contiene una fusión del proyecto `proyec` (flujo de selección de mazos, PvP local y red TCP) con las funciones de `cosoV3` (carga local de imágenes, carta ambiente y cargas especiales), conservando los nombres principales de los formularios y controles existentes.

## Abrir y compilar

1. Extrae toda la carpeta del ZIP en una ubicación normal de Windows.
2. Abre `ChronosArena.sln` con SharpDevelop.
3. Comprueba que el proyecto use **.NET Framework 4.0**.
4. Compila la solución desde **Compilar → Compilar solución**.
5. Ejecuta `ChronosArena.exe` desde `bin\Debug` o `bin\Release`.

La carpeta `Imagenes` debe permanecer al lado del ejecutable. El `.csproj` está configurado para copiarla automáticamente al directorio de salida.

## Modos de juego

### Local: jugador contra IA

El primer menú de modos permite iniciar una partida contra la computadora. La IA recibe cinco personajes y elige sus acciones durante la batalla. Si gana el dado previo, selecciona automáticamente una carta ambiente y la interfaz indica que la eligió la computadora.

### Dos jugadores en el mismo PC

Los jugadores eligen cinco personajes cada uno, escriben sus nombres en la preparación y alternan los turnos en el mismo equipo. El dado determina quién comienza y elige el ambiente.

### En línea por LAN

Esta opción usa TCP/IP en la **misma red local**; no es un servicio de Internet ni requiere un servidor externo.

1. En el primer PC, pulsa **EN LÍNEA → Sí (crear partida)**. Ese equipo será el anfitrión y mostrará sus direcciones IP.
2. En el segundo PC, pulsa **EN LÍNEA → No (unirse)** e introduce la IP del anfitrión.
3. Ambos equipos deben estar conectados a la misma red y usar la misma versión del proyecto y el mismo catálogo de personajes.
4. En Windows Firewall, permite Chronos Arena o el tráfico TCP entrante por el **puerto 5000** en el equipo anfitrión. Si el router tiene aislamiento de clientes Wi-Fi, desactívalo para que los equipos puedan comunicarse.
5. Cada jugador escoge sus cinco cartas y pulsa **LISTO**; después ambos confirman **COMENZAR BATALLA**.
6. El anfitrión lanza los dados para ambos jugadores. El ganador elige el ambiente y la elección se comparte con el otro equipo.

El juego envía por la conexión las acciones de batalla y comprueba que ambos equipos mantengan el mismo estado. El contador de 30 segundos corre en el PC del jugador al que le toca actuar.

## Cambios incluidos

- Carga de imágenes desde `Imagenes` mediante `CargadorLocal`; no se usa `PictureBox.LoadAsync` ni se consultan URL HTTP para mostrar las imágenes.
- `CartaAmbiente` con Tsunami, Huracán, Erupción Volcánica y Deslave. Incluye modificadores de HP, defensa y ataque por clan. El cálculo de daño usa `switch`.
- `CargasEspecial` en `Personaje`: aumenta una carga al completar el turno o pasarlo; la habilidad especial requiere dos cargas y 20 puntos de maná.
- `FormPrePartida` con nombres, dados y mensaje del equipo que comienza.
- `FormSeleccionAmbiente` con las cuatro imágenes, resumen, selección/confirmación y comunicación de la carta elegida en LAN.
- Campo de batalla reorganizado: temporizador separado del panel de ambiente, imagen y descripción del ambiente activo, nombre de quien lo eligió, reserva de hasta cuatro cartas, botón **PASAR TURNO**, indicadores de carga y empatía, y banner dinámico del turno.
- Modo PvP local y modo PvP por LAN; modo jugador contra IA.
- Protección de lectura del catálogo ante líneas incorrectas o números inválidos, y `DoubleBuffered` en los formularios principales.
- Las expresiones `??` del código fueron reemplazadas por comprobaciones ternarias equivalentes para evitar que esos símbolos se confundan con texto dañado. No elimines los operadores `? :` restantes: forman parte de la sintaxis normal de C#.

## Comprobación y limitaciones conocidas

Se revisó el XML del proyecto, la existencia de todos los archivos referenciados, los nombres de imágenes usadas, los bloques de llaves/paréntesis, las rutas locales, la presencia de `DoubleBuffered` en los formularios y la ausencia de `LoadAsync`, URL HTTP y operadores `??` en los archivos `.cs`.

**No se pudo compilar ni ejecutar la interfaz WinForms en este entorno**, porque no hay un compilador compatible de .NET/Windows Forms instalado aquí. Por eso esta revisión estática no sustituye la compilación y una partida real en Windows/SharpDevelop. En especial, la conexión LAN debe probarse con dos PCs conectados a la misma red y el firewall configurado.
