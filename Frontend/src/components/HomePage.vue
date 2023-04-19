<template>
    <div>
        <Header />        
        <h1>Hello {{ student.name }}, Welcome to Home page</h1>
        <img style="margin-top: 100px;" class="logo" alt="Vue logo" src="../assets/welcome.png">
    </div>
</template>

<script>

import Header from './Header.vue';

export default {
    name: 'HomePage',
    components:{
        Header
    },
    data(){
        return{
            name:'',
            student: {}
        }
    },
    mounted(){
        let user = localStorage.getItem("student-info")
        this.student = JSON.parse(user);            
        if(!user){
            this.$router.push({name:'SignUp'})   
        }
    }
}
</script>
