<template>
    <div class="nav">
        <router-link class="btn btn-light btn-outline-primary" to="/">Home</router-link>
        <router-link class="btn btn-light btn-outline-primary" to="/my-courses">My Courses</router-link>
        <router-link class="btn btn-light btn-outline-primary" to="/my-evaluations">My Evaluations</router-link>                
        <a class="btn btn-light btn-outline-primary" v-on:click="logout" href="#">Logout</a>        
    </div>
</template>

<script>
    export default {
        name:'Header',
        methods:{
            logout(){
                localStorage.clear();
                this.$router.push({name:'LoginPage'})
            }
        },
    }     
</script>

<style>
/* .nav{
    background-color: #333;
    overflow: hidden;    
} */

.nav a{
    float: left;
    /* color: #f2f2f2f2; */
    padding:14px 14px;
    text-align: center;
    font-size: 17px;
    text-decoration: none;
    margin-right: 20px;
    margin-bottom: 200px;
}

.nav a:hover{
    background: #ddd;
    color:#333;
}

</style>