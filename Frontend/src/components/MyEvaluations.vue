<template>
    <div>
        <Header />
        <h1>Hello {{this.student.name}}, Welcome to My Evaluations</h1>
        <table id="table">
            <tr>
                <td><b>Course Name</b></td>
                <td><b>Grade</b></td>
                <td><b>Stars</b></td>
                <td><b>Description</b></td>
            </tr>
            <tr v-for="item in myEvaluations" :key="item.id">
                <td>{{ item.course_Name }}</td>
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

import Header from './Header.vue';
import axios from 'axios';

export default {
    name: 'MyEvaluations',
    components:{
        Header
    },
    data(){
        return{
            myEvaluations:[],
            student: {},
            selectMode: 'single',
            courseSelected:{},   
            target:[]        
        }        
    },
    methods:{
        GetAllEvaluationsByStudentID(){
            axios.get("https://localhost:7035/api/Evaluation/GetAllEvaluationsByStudentID", {params: {studentID: this.student.id}})
            .then(response => {
                if(response){
                    this.myEvaluations= response.data
                    console.log(this.myEvaluations)
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
        let user = localStorage.getItem("student-info")
        this.student = JSON.parse(user);      
        
        if(user){
            this.GetAllEvaluationsByStudentID()
        } else{
            this.$router.push({name:'SignUp'})   
        }        
    }

}
</script>
