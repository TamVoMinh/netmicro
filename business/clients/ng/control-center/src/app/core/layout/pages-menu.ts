import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Home',
    icon: 'home-outline',
    link: '/web/home',
    home: true,
  },
  {
    title: 'Dashboard',
    icon: 'color-palette-outline',
    link: '/web/dashboard',
  },
  {
    title: 'Managements',
    icon: 'monitor-outline',
    children: [
      {
        title: 'Users',
        icon: 'people-outline',
        link: '/web/user-management',
      },
      {
        title: 'Clients',
        icon: 'person-done-outline',
        link: '/web/client-management',
      },
      {
        title: 'APIs',
        icon: 'layers-outline',
        link: '/web/api-management',
      }
    ],
  },
  {
    title: 'Log out',
    icon: 'log-out-outline'
  }
  // {
  //   title: 'Clients',
  //   icon: 'person-done-outline',
  //   children: [
  //     {
  //       title: 'Form Inputs',
  //       link: '/pages/forms/inputs',
  //     },
  //     {
  //       title: 'Form Layouts',
  //       link: '/pages/forms/layouts',
  //     },
  //     {
  //       title: 'Buttons',
  //       link: '/pages/forms/buttons',
  //     },
  //     {
  //       title: 'Datepicker',
  //       link: '/pages/forms/datepicker',
  //     },
  //   ],
  // },
  // {
  //   title: 'APIs',
  //   icon: 'layers-outline',
  //   link: '/pages/ui-features',
  //   children: [
  //     {
  //       title: 'Grid',
  //       link: '/pages/ui-features/grid',
  //     },
  //     {
  //       title: 'Icons',
  //       link: '/pages/ui-features/icons',
  //     },
  //     {
  //       title: 'Typography',
  //       link: '/pages/ui-features/typography',
  //     },
  //     {
  //       title: 'Animated Searches',
  //       link: '/pages/ui-features/search-fields',
  //     },
  //   ],
  // },
];
