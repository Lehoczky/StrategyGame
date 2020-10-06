export class Unit {
  name: string;
  price: number;
  attack: number;
  defense: number;
  costPerTurn: number;
  coralPerTurn: number;

  constructor(name, price, attack, defense, coralPerTurn, costPerTurn) {
    this.name = name;
    this.price = price;
    this.attack = attack;
    this.defense = defense;
    this.costPerTurn = costPerTurn;
    this.coralPerTurn = coralPerTurn;
  }
}

export const ATTACK_SEAL = new Unit('rohamfóka', 50, 6, 2, 1, 1);
export const BATTLE_SEA_HORSE = new Unit('csatacsikó', 50, 2, 6, 1, 1);
export const LASER_SHARK = new Unit('lézercápa', 100, 5, 5, 3, 2);
