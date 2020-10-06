import { Component } from '@angular/core';
import { StatService } from '../../services/stat.service';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.scss'],
})
export class StatsComponent {
  stat$ = this.statService.stat$;

  constructor(public statService: StatService) {}
}
