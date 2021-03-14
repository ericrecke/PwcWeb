export interface Header {
  timestamp: number;
}

export interface Arrival {
  time: number;
  delay: number;
}

export interface Departure {
  time: number;
  delay: number;
}


export interface Estacione {
  stop_id: string;
  stop_name: string;
  arrival: Arrival;
  departure: Departure;
}

export interface Linea {
  Trip_Id: string;
  Route_Id: string;
  Direction_ID: number;
  start_time: string;
  start_date: string;
  Estaciones: Estacione[];
}

export interface Entity {
  ID: string;
  Linea: Linea;
}

export interface RootObjectGTFS {
  Header: Header;
  Entity: Entity[];
}
