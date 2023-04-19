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
                <td>
                    <button type="button" class="btn btn-primary" data-toggle="modal" v-on:click="openModal(item)">
                        Add New Score
                    </button>
                    <!-- <AddScoreModal visible="false" variant="success"></AddScoreModal> -->
                </td>
            </tr>
        </table>

        <button v-b-modal-1>Launch demo modal</button>

        <b-modal id="modal-1" title="Bootstrap vue - modal">
            <p>Hola popo</p>
        </b-modal>
        
    </div>
</template>

<script>

import Header from './Header.vue';
import axios from 'axios';
import AddScoreModal from './AddScoreModal.vue';

export default {
    name: 'MyCourses',
    components:{
        Header,
        AddScoreModal,
    },
    data(){
        return{
            myCourses:[{}],
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
                // debugger               
                if(response){
                    this.myCourses= response.data                    
                }else{
                    console.log("The user doesn´t exist")
                }
            })                
        },
        addScore(item){
            var payload = {
                Id: undefined,
                Course_Student_Id: item.course_Student_Id,
                Stars: 5,
                Description: "This is a test"
            }

            axios.post('https://localhost:7035/api/Evaluation/PostNewEvaluation', payload)            
        },
        openModal(item){
            console.log(item)
            

        }
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