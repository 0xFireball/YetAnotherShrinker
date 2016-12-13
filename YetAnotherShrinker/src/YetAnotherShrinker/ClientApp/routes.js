
import Landing from './layouts/Landing'
import NotFound from './layouts/NotFound'

const main = [
  {
    path: '/',
    name: 'landing',
    component: Landing
  },
  {
    path: '/landing',
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
