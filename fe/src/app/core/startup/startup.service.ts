import { Injectable, Injector, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { zip } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MenuService, SettingsService, TitleService, ALAIN_I18N_TOKEN } from '@delon/theme';
import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';
import { ACLService } from '@delon/acl';

import { NzIconService } from 'ng-zorro-antd/icon';
import { ICONS_AUTO } from '../../../style-icons-auto';
import { ICONS } from '../../../style-icons';
import { NzMessageService } from 'ng-zorro-antd';

/**
 * Used for application startup
 * Generally used to get the basic data of the application, like: Menu Data, User Data, etc.
 */
@Injectable()
export class StartupService {
  constructor(
    iconSrv: NzIconService,
    private menuService: MenuService,
    private settingService: SettingsService,
    private aclService: ACLService,
    private titleService: TitleService,
    @Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
    private httpClient: HttpClient,
    private injector: Injector
  ) {
    iconSrv.addIcon(...ICONS_AUTO, ...ICONS);
  }



  load(): Promise<any> {
    // only works with promises
    // https://github.com/angular/angular/issues/15088
    return new Promise((resolve, reject) => {
      // http
      // this.viaHttp(resolve, reject);
      // mock：请勿在生产环境中这么使用，viaMock 单纯只是为了模拟一些数据使脚手架一开始能正常运行
     // this.viaMock(resolve, reject);
     this.httpClient
     .post('app',this.settingService.user)
     .pipe(
       catchError((res:any)=>{
         resolve(null);
         return null;
       }),
     )
       .subscribe(
         (res:any)=>{
          // if(res!= null) this.injector.get(NzMessageService).success(JSON.stringify(res));
           const app:any=res.data;
           console.log(res);
           console.log(app);
           // 应用信息：包括站点名、描述、年份
           this.settingService.setApp(app.project);
           // 用户信息：包括姓名、头像、邮箱地址
         //  this.settingService.setUser(app.user);
            // ACL：设置权限为全量
           // this.aclService.
           //  this.aclService.setFull(true);
          this.aclService.add(app.acl);

            // 初始化菜单
           this.menuService.add(app.menu);
           // 设置页面标题的后缀
           this.titleService.suffix = app.project.name;
         },
         ()=>{},
         ()=>{ resolve(null);},
       );
    });
  }
}
