import HomePage from './components/HomePage.vue'
import SignUp from './components/SignUp.vue'
import {createRouter, createWebHistory} from 'vue-router'
import LoginPage from './components/LoginPage.vue'
import MyCourses from './components/MyCourses.vue'
import MyEvaluations from './components/MyEvaluations.vue'
import AllEvaluations from './components/AllEvaluations.vue'


const routes = [
    {
        name: "HomePage",
        component: HomePage,
        path:"/"
    },
    {
        name: "SignUp",
        component: SignUp,
        path:"/sign-up"
    },
    {
        name: "LoginPage",
        component: LoginPage,
        path:"/login-page"
    },
    {
        name: "MyCourses",
        component: MyCourses,
        path:"/my-courses"
    },
    {
        name: "MyEvaluations",
        component: MyEvaluations,
        path:"/my-evaluations"
    },
    {
        name: "AllEvaluations",
        component: AllEvaluations,
        path:"/all-evaluations"
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router