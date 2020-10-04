import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { BuildingsPageComponent } from 'src/app/features/buildings/pages/buildings/buildings.page.component';
import { ComponentType } from '@angular/cdk/portal';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  logo = 'Undersea';
  isDialogOpen = false;
  components = BuildingsPageComponent;
  features: object[] = [];

  constructor(private router: Router, private route: ActivatedRoute, private dialog: MatDialog) { }

  ngOnInit() {
    this.features = [
      { name: 'Épületek', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Támadás', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Fejlesztések', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Harc', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Ranglista', route: 'features/buildings', component: BuildingsPageComponent },
      { name: 'Sereg', route: 'features/buildings', component: BuildingsPageComponent }
    ];

    if (!this.isDialogOpen) {
      this.router.navigate(['strategy']);
    }
  }

  openFeatureDialog(featureRoute: string, featureComp: ComponentType<BuildingsPageComponent>) {
    this.isDialogOpen = true;
    this.router.navigate([featureRoute], { relativeTo: this.route });
    let dialogRef = this.dialog.open(featureComp);
    dialogRef.afterClosed().subscribe(res => {
      this.isDialogOpen = false;
      this.router.navigate(['strategy']);
    });
  }

}
