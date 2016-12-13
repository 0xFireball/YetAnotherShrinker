<template>
  <div class="shrink-layout">
    <!--<img src="./assets/logo.png">-->
    <intro></intro>
    <urlShrinkInput></urlShrinkInput>
    <devCredits></devCredits>
  </div>
</template>

<script>
import Intro from './components/Intro'
import urlShrinkInput from './components/urlShrinkInput'
import devCredits from './components/devCredits'

export default {
  data () {
    return {   
    }
  },
  components: {
    Intro,
    urlShrinkInput,
    devCredits
  }
}
</script>

<style>
  #app {
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
  
  body {
    background: #f7f7f7;
  }
  
  .invisible {
    display: none;
  }
  
  .space-v {
    margin-top: 5%;
    margin-bottom: 5%;
  }
</style>