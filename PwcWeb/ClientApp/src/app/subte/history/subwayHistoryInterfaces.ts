export interface History {
  id: number;
  line: string;
  result: string;
  date: Date;
}

export interface Lines {
  id: string;
}

export interface HistoryView {
  histories: History[];
  lines: Lines[];
}
