
import ShrinkPlace from './layouts/ShrinkPlace'
import NotFound from './layouts/NotFound'

const main = [
  {
    path: '/',
    name: 'landing',
    component: ShrinkPlace
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
