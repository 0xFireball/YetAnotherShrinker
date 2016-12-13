<template>
  <div v-md-theme="'apptheme'">
    <toolbar></toolbar>

    <transition name="md-router">
      <router-view></router-view>
    </transition>
  </div>
</template>

<script>
import Toolbar from './components/Toolbar'
export default {
  data () {
    return {
    }
  },
  components: {
    Toolbar
  }
}
</script>

<style>
</style>