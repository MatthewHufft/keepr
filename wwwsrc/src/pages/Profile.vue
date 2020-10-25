<template>
  <div class="profile container-fluid">
    <h1>This is your profile</h1>
    <div class="row">
    <VaultComponent v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
    </div>
  </div>
</template>

<script>
import VaultComponent from "../components/VaultComponent.vue";
export default {
name: "Profile",
mounted(){
  },
  data(){
    return{}
  },
  computed:{
    vaults(){
      return this.$store.state.vaults;
    }
  },
  methods:{

  },
  props: [""],
  components:{
    VaultComponent
  }
};
</script>

<style>

</style>