export interface Arrival {
  time: number;
  delay: number;
  fecha: Date;
}

export interface Departure {
  time: number;
  delay: number;
  fecha: Date;
}

export interface Station {
  stop_id: string;
  stop_name: string;
  id: string;
  arrival: Arrival;
  departure: Departure;
}

export interface RootObject {
  id: string;
  id_Route: string;
  line: string;
  direction: number;
  time_Start: string;
  date_Start: string;
  stations: Station[];
}

export interface MainObject {
  gtfs: RootObject[];
  searchValue: RootObject;
}
