import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { ComponentType } from '@angular/cdk/portal';
import { BuildingsPageComponent } from 'src/app/features/buildings/pages/buildings/buildings.page.component';
import { UnitsPageComponent } from 'src/app/features/units/pages/units/units.page.component';
import { BattlePageComponent } from 'src/app/features/battle/pages/battle/battle.page.component';
import { AttackPageComponent } from 'src/app/features/attack/pages/attack/attack.page.component';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  logo = 'Undersea';
  isDialogOpen = false;
  features: object[] = [];

  constructor(private router: Router, private route: ActivatedRoute, private dialog: MatDialog) { }

  ngOnInit() {
    this.features = [
      { name: 'Épületek', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Támadás', route: 'features/attack', component: AttackPageComponent },
      { name: 'Fejlesztések', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Harc', route: 'features/battle', component: BattlePageComponent },
      { name: 'Ranglista', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Sereg', route: 'features/units', component: UnitsPageComponent }
    ];

    if (!this.isDialogOpen) {
      this.router.navigate(['strategy']);
    }
  }

  openFeatureDialog(featureRoute: string, featureComp: ComponentType<Component>) {
    this.isDialogOpen = true;
    this.router.navigate([featureRoute], { relativeTo: this.route });
    let dialogRef = this.dialog.open(featureComp);
    dialogRef.afterClosed().subscribe(res => {
      this.isDialogOpen = false;
      this.router.navigate(['strategy']);
    });
  }

}
