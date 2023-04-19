<template>    
  <router-view></router-view>
</template>

<script>

export default {
  name: 'App',
  components: {
   
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  
}

body{
  padding: 0;
  margin:0;
}

.logo{
    width:300px
}

.register input, .login input{
    width:300px;
    height:30px;
    padding-left: 20px;
    display: block;
    margin-bottom: 30px;
    margin-right: auto;
    margin-left: auto;
    border: 1px solid skyblue;
}

.register button, .login button{
    width: 300px;
    height: 40px;
    border: 1px solid skyblue;
    background: skyblue;
    color: white;
    cursor:pointer;
}

</style>
