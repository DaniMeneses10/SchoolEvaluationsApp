<template>
    <div>
        <div v-if="!OpenClose" class="modal fade show"
        tabindex="-1" aria-labelledby="exampleModalLabel" aria-modal="true" role="dialog"
            style="display:block">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Modal title</h5>
                    <button type="button" class="btn-close" @click="OpenCloseFun()" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Modal body text goes here.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" @click="OpenCloseFun()" :class="'btn btn-'+ variant">Save changes</button>
                </div>
                </div>
            </div>
        </div>

        <div>
            <button type="button" @click="OpenCloseFun()" :class="'btn btn-'+ variant">Add Score</button>
        </div>
        
    </div>

</template>

<script>


export default {
    name: 'AddScoreModal',
    props:{
        visible: Boolean,
        variant: String,
    },
    data(){
        return{
            OpenClose: this.visible
        }
    },
    methods:{
        OpenCloseFun(){
            this.OpenClose = !this.OpenClose
        }
    },
    watch:{
        visible: function(newVal, oldVal ){
            this.OpenClose = newVal
            console.log('new ' + newVal + '==' + oldVal)
        }
    }
}
</script>
