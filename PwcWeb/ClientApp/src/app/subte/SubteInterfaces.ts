export interface Header {
  gtfs_realtime_version: string;
  incrementality: number;
  timestamp: number;
}

export interface InformedEntity {
  agency_id: string;
  route_id: string;
  route_type: number;
  trip?: any;
  stop_id: string;
}

export interface Translation {
  text: string;
  language: string;
}

export interface HeaderText {
  translation: Translation[];
}

export interface Translation2 {
  text: string;
  language: string;
}

export interface DescriptionText {
  translation: Translation2[];
}

export interface Alert {
  active_period: any[];
  informed_entity: InformedEntity[];
  cause: number;
  effect: number;
  url?: any;
  header_text: HeaderText;
  description_text: DescriptionText;
}

export interface Entity {
  id: string;
  is_deleted: boolean;
  trip_update?: any;
  vehicle?: any;
  alert: Alert;
}

export interface RootObject {
  header: Header;
  entity: Entity[];
}

export interface Subte {
  Id: string;
  Letra: string;
  Name: string;
  HeaderInfo: string;
  DescriptionInfo: string;
  Fecha: Date;
}
