export class Building {
  name: string;
  price: number;
  population: number;
  units: number;
  coralPerTurn: number;

  constructor(name, price, population, units, coralPerTurn) {
    this.name = name;
    this.price = price;
    this.population = population;
    this.units = units;
    this.coralPerTurn = coralPerTurn;
  }
}

export const FLOW_CONTROLLER = new Building(
  'áramlásirányító',
  1000,
  50,
  0,
  200,
);
export const REEF_CASTLE = new Building('zátonyvár', 1000, 0, 200, 0);
