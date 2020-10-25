<template>
  <div class="profile container-fluid">
    <h1>This is your profile</h1>
    <button
          class="btn btn-danger m-2 bg-danger text-white"
          type="button"
          data-toggle="modal"
          data-target="#newVaultModal"
        >New Vault</button>
    <div
          class="modal fade"
          id="newVaultModal"
          tabindex="-1"
          role="dialog"
          aria-labelledby="newVaultModalLabel"
          aria-hidden="true"
        >
          <div class="modal-dialog shadow-lg" role="document">
            <div class="modal-content text-light">
              <div class="modal-header bg-danger">
                <h5 class="modal-title text-light" id="newVaultModalLabel">Create Vault</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <form @submit.prevent="addVault">
                <input
                  class="form-control forms-custom"
                  type="text"
                  placeholder="Vault Name... "
                  v-model="newVault.name"
                  required
                />
                <input
                  class="form-control forms-custom"
                  type="text"
                  placeholder="Description ..."
                  v-model="newVault.description"
                />
                <input
                  class="form-control forms-custom"
                  type="checkbox"
                  v-model="newVault.isPrivate"
                />
                <div class="modal-footer justify-content-center">
                  <button
                    type="submit"
                    class="btn btn-danger"
                  >Create Vault</button>
                </div>
              </form>
            </div>
          </div>
        </div>
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
    return{
      newVault:{
        name: "",
        description: "",
        isPrivate: false
      }
    }
  },
  computed:{
    vaults(){
      return this.$store.state.vaults;
    }
  },
  methods:{
    addVault(){
      this.$store.dispatch("createVault", this.newVault);
      this.newVault = {name: "", description: "", isPrivate: false};
    }
  },
  props: [""],
  components:{
    VaultComponent
  }
};
</script>

<style>

</style>