function showCourse(course = {}) {
    var defaultCourse = {
        courseName: 'Name of the course',
        courseDuation: 'Duration of the course',
        courseOwner: 'Owner of the course'
    };

    Object.assign(defaultCourse, course);

    console.log(defaultCourse);
}


export { showCourse };