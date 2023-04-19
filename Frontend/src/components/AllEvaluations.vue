<template>
    <div>        
        <h1>Hi, Welcome to the Admin Module</h1>

        <div class="register" style="margin-top:50px">
            <row>
                <input type="text" v-model="courseName" placeholder="Enter Course Name">
                <input type="text" v-model="stars" placeholder="Stars">   
                <input type="text" v-model="studentName" placeholder="Enter Student Name">
                <input type="text" v-model="grade" placeholder="Grade">            
            </row>
            
            <button v-on:click="getAllEvaluations">Search</button>
        </div>

        <h2 style="margin-top: 50px;" >Table of Evaluations</h2>

        <h4 v-if="appear">popo</h4>

        <table id="table">
            <tr>
                <td><b>Student Name</b></td>
                <td><b>Course Name</b></td>
                <td><b>Grade</b></td>
                <td><b>Stars</b></td>
                <td><b>Description</b></td>
            </tr>
            <tr v-for="item in evaluations" :key="item.evaluation_Id">
                <td>{{ item.full_name }}</td>
                <td>{{ item.course_name }}</td>
                <td>{{ item.grade }}</td>
                <td>{{ item.stars }}</td>
                <td>{{ item.description }}</td>
                <td><button type="button" 
                            class="btn btn-primary m-2 fload-end" 
                                    data-bs-toggle="modal"
                                    data-bs-target="#editModal"
                                    @click="editScore(item)"
                                    >Edit Score</button>
                    <button type="button" 
                            class="btn btn-danger m-2 fload-end" 
                                    data-bs-toggle="modal"
                                    data-bs-target="#editModal"
                                    @click="deleteScore(item)"
                                    >Delete Score</button>
                </td>                               
            </tr>
        </table>
    </div>
</template>

<script>

import axios from 'axios';

export default {
    name: 'AllEvaluations',
    components:{      

    },
    data(){
        return{
            courseName:null,
            stars:null,  
            studentName:null,
            grade:null,
            evaluations:[{}],      
        }        
    },
    created(){              
    },
    methods:{
        getAllEvaluations(){
            axios.get("https://localhost:7035/api/Evaluation/GetAllEvaluations", {params: {courseName: this.courseName, 
                                                                                            stars: this.stars,
                                                                                            studentName: this.studentName,
                                                                                            grade: this.grade}})
            .then(response => {
                if(response){
                    this.evaluations= response.data                    
                    this.courseName = null,
                    this.stars = null
                }else{
                    console.log("The user doesn´t exist")
                }
            })                
        },
        editScore(item){
            console.log(item)
        },
        deleteScore(item){
            console.log(item)
        }
    },
    mounted(){
        this.getAllEvaluations()
    }
}
</script>
<style>
    tr,td {
        text-align:left;    
        border-style: dotted;
        padding: 10px    
    }

    td{     
        height: 40px;  
        border: 1px solid black;           
    }

    table {        
        margin-left: auto;
        margin-right: auto;
        margin-top: 50px;        
    }

   
         
</style>


