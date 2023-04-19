<template>
    <div>
        <img style="margin-top: 100px;" class="logo" alt="Vue logo" src="../assets/signup.png">
        <h1 style="margin-top: 20px;" >Sign Up</h1>
        <div class="register">
            <input type="text" v-model="name" placeholder="Enter Name">
            <input type="text" v-model="lastName" placeholder="Last Name">
            <button v-on:click="signUp">Sign Up</button>
            <p style="margin-top: 20px;">
                <router-link to="/login-page">Login</router-link>
            </p>
        </div>

        

    </div>
</template>

<script>
    import axios from 'axios'

    export default{
        name: 'SignUp',
        data(){
            return{
                name:'',
                lastName:'',
                user:{}                
            }
        },
        methods:{
            signUp(){
                axios.get("https://localhost:7035/api/Student/SignUp", {params: {name: this.name,last_name: this.lastName}})
                .then(response => {
                    if(response){
                        this.user = response.data
                        localStorage.setItem("student-info",JSON.stringify(response.data))
                        this.$router.push({name:'HomePage'})                        
                    }else{
                        console.log("The user doesn´t exist")
                    }
                })                
            }
        },
        mounted(){
            let user = localStorage.getItem("student-info")
            if(user){
                this.$router.push({name:'HomePage'})   
            }
        }
    }
</script>

