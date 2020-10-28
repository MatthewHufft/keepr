import Swal from "sweetalert2";
export default class NotificationService {
  static async confirmAction(
    title = "Are you sure?",
    text = "You cant go back from here!"
  ) {
    try {
      let res = await Swal.fire({
        title: title,
        text: text,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DC3545",
        cancelButtonColor: "#17A2B8",
        confirmButtonText: "Yes, delete it!",
      });
      if (res.value) {
        return true;
      }
      return false;
    } catch (error) {}
  }
  static toast(title = "Default Toast", timer = 1500) {
    // @ts-ignore
    Swal.fire({
      title: title,
      timer: timer,
      toast: true,
      position: "center",
      showConfirmButton: false,
    });
  }
  static success(title = "Success!") {
    // @ts-ignore
    Swal.fire({
      title: title,
      text: "Nice!",
      position: "top-end",
      icon: "success",
      showConfirmButton: false,
      timer: 2000,
    });
  }
}
