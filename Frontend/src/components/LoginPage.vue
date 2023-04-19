<template>
    <div>
        <img style="margin-top: 100px;" class="logo" alt="Vue logo" src="../assets/login.png">
        <h1 style="margin-top: 20px;">Login</h1>
        <div class="login">
            <input type="text" v-model="name" placeholder="Enter Name">
            <input type="text" v-model="lastName" placeholder="Last Name">
            <button v-on:click="login">Login</button>
            <p style="margin-top: 20px;">
                <router-link to="/sign-up">Sign Up</router-link>
            </p>

        </div>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: 'LoginPage',
        data(){
            return{
                name:'',
                lastName:'',
                user:{}
            }
        },
        methods:{        
            login(){                
                axios.get("https://localhost:7035/api/Student/Login", {params: {name: this.name,last_name: this.lastName}})
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
            this.user = localStorage.getItem("student-info")            
            if(this.user){
                this.$router.push({name:'HomePage'})   
            }
        }
    }

</script>

