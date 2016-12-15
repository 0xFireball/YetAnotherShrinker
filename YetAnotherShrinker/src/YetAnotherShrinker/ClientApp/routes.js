
import ShrinkPlace from './layouts/ShrinkPlace'
import StatsPlace from './layouts/StatsPlace'
import NotFound from './layouts/NotFound'

const main = [
  {
    path: '/',
    name: 'landing',
    component: ShrinkPlace
  },
  {
    path: '/s/:path',
    name: 'statsview',
    component: StatsPlace
  },
  {
    path: '/home',
    redirect: '/'
  }
]

const error = [
  {
    path: '*',
    name: 'error',
    component: NotFound
  }
]

export default [].concat(main, error)
