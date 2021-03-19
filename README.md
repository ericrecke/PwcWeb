# Pwc-Web-ER
 Sitio web Eric Recke - PWC Argentina
<div class="card" style="margin-bottom: 10rem;">
  <h1>Documentación</h1>
  <p>Se realizó el sitio web utilizando las herramientas de .Net Core y Angular como GUI.</p>
  <p>
    Se realizó una vista de Inicio donde se puede ver un header con el titulo y una imagen de fondo. Al igual que tres opciones para utilizar:
    Estado del Servicio
    Tiempos de Arribo
    Historial de Incidentes
  </p>
  <p>Se utilizó un Contexto de Entity Framework para hacer la conexión a la base de datos, con el modelo y mapping de Core.</p>
  <p>
    <span class="font-weight-bold">En la vista Estado del servicio:</span><br />
    + Se muestra el listado obtenido de la Api de Transporte con el reporte del estado del servicio, con una redirección a su sitio web para tener más información.<br />
    + Tambien se queda registrado en el Historial en la tabla "Subway_History" la cual guarda todas las lineas con el mensaje y la fecha para utilizarla en el historial de Incidentes.<br />
    + Se utilizan 2 tipos de modelos uno en C# para recibir la Data que viene de la Api y uno para Ts para poder mostrarlo en la vista que es un pasaje de clase de C# a Ts.
    (C# -> Subtes, TS -> SubteInterface)
  </p>
  <p>
    <span class="font-weight-bold">En la vista Tiempos de Arribo:</span><br />
    + Se muestra el listado obtenido de la Api de Transporte con el reporte de GTFS, con el listado de los arribos y subidas de cada estación de las lineas.<br />
    + Tambien tiene un buscador donde se chequea la Linea, la Estación y el Destino. y te devuelve la selección con el Tiempo de arribo.<br />
    + Se utilizan 2 tipos de modelos uno en C# para recibir la Data que viene de la Api y uno para Ts para poder mostrarlo en la vista que es un pasaje de clase de C# a Ts.
    (C# -> SubtesGTFS, TS -> SubteGTFSInterface)
  </p>
  <p>
    <span class="font-weight-bold">En la vista Historial de Incidentes:</span><br />
    + Se muestra el listado obtenido de la base de Datos con los reportes guardado de los estados del Servicio en una tabla con la Linea, el resultado y la fecha.<br />
    + Tambien tiene un buscador donde se chequea la Linea, y una fecha y te devuelve en la tabla la fecha seleccionada y la linea.<br />
    + Se utilizan 2 tipos de modelos uno en C# para recibir la Data que viene de la Api y uno para Ts para poder mostrarlo en la vista que es un pasaje de clase de C# a Ts.
    (C# -> SubwayHistory, TS -> subwayHistoryInterface)
  </p>
  <p>Se uso .Net Core, con Angular. Al igual que tambien se usaron extensiones de Bootstrap, Typescript(Un Inject para la url, HttpClient, HttpHeaders, HttpParams para los recibos de Información)</p>
</div>
