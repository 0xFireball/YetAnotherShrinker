// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'

// styles
import './assets/styles/normalize.css'
import './assets/styles/ffskeleton.css'

/* eslint-disable no-new */
new Vue({
  el: '#app',
  template: '<App />',
  components: { App }
})
