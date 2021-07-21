Student = {
    Params: {
        studentId:0
    },
    OnDelete: function () {
        document.getElementById("studentId").value = Student.Params.studentId;
    },
}