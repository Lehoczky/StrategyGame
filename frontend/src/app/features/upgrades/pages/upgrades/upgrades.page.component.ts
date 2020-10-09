import { Component } from '@angular/core';
import { UpgradeService } from 'src/app/features/upgrades/upgrade.service';
import { Upgrade } from '../../upgrade.model';

@Component({
  templateUrl: './upgrades.page.component.html',
  styleUrls: ['./upgrades.page.component.scss'],
})
export class UpgradesPageComponent {
  upgrades$ = this.upgradeService.upgrades$;
  selectedIndex: number;
  selectedUpgrade: Upgrade;

  constructor(public upgradeService: UpgradeService) { }

  selectUpgrade(index: number, upgrade: Upgrade) {
    this.selectedIndex = index;
    this.selectedUpgrade = upgrade;
  }

  purchaseUpgrade() {
    if (this.selectedUpgrade) {
      this.upgradeService.purchaseUpgrade(this.selectedUpgrade);
    }
  }
}
