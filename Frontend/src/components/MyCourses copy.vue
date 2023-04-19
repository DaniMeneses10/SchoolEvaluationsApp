<template>
    <div>
        <Header />
        <h1>Hello {{this.student.name}}, Welcome to My Courses</h1>
        <table id="table">
            <tr>
                <td><b>Course Name</b></td>
                <td><b>Grade</b></td>
            </tr>
            <tr v-for="item in myCourses" :key="item.id">
                <td>{{ item.course_Name }}</td>
                <td>{{ item.grade }}</td>
            </tr>
        </table>
    </div>
</template>

<script>

import Header from './Header.vue';
import axios from 'axios';

export default {
    name: 'MyCourses',
    components:{
        Header,
    },
    data(){
        return{
            myCourses:[],
            student: {},
            courseFields:[
                {key:'course_Name', label:'Course Name'},
                {key:'grade', label:'Grade'}
            ],
            selectMode: 'single',
            courseSelected:{},           
        }        
    },
    created(){              
    },
    methods:{
        GetAllCoursesByStudentID(){
            axios.get("https://localhost:7035/api/Course/GetAllCoursesByStudentID", {params: {studentID: this.student.id}})
            .then(response => {
                if(response){
                    this.myCourses= response.data
                    
                    console.log(this.myCourses)
                }else{
                    console.log("The user doesn´t exist")
                }
            })                
        },
    },
    mounted(){
        let user = localStorage.getItem("student-info")        
        this.student = JSON.parse(user);

        if(user){
            this.GetAllCoursesByStudentID()
        } else{
            this.$router.push({name:'SignUp'})   
        }  
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
        margin-top: 100px;        
    }
         
</style>


