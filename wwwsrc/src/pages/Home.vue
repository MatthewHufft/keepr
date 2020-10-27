<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="card-columns">
        <KeepComponent v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>
      </div>
    </div>
  </div>
</template>

<script>
import KeepComponent from "../components/KeepComponent";
export default {
  name: "home",
  mounted(){
    this.$store.dispatch("getKeeps");
  },
  data(){
    return{}
  },
  computed:{
    keeps(){
      return this.$store.state.keeps;
    }
  },
  methods:{

  },
  props: [""],
  components:{KeepComponent}
};
</script>
