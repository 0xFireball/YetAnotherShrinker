<template>
  <div class="hello">
    <h1>{{ titleText }}</h1>
    <p>Server says: <b>{{ msgData }}</b></p>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'hello',
  data () {
    return {
        titleText: 'Welcome to VueAndNfx',
        msgData: ''
    }
  },
  mounted: function () {
    let vm = this
    axios.get('/a/data')
      .then(function (response) {
        // console.log(response)
        vm.msgData = response.data
      })
      .catch(function (error) {
        console.log(error)
      });
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1,
  h2 {
    font-weight: normal;
    font-family: 'Raleway';
  }
  
  ul {
    list-style-type: none;
    padding: 0;
  }
  
  li {
    display: inline-block;
    margin: 0 10px;
  }
  
  a {
    color: #42b983;
  }
</style>