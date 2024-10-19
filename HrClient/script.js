$(document).ready(function() {
    // Проверяем, открывалось ли модальное окно
    if (!localStorage.getItem('loginModalShown')) {
        $('#loginModal').modal('show');
        // Сохраняем состояние, что модальное окно открывалось
        localStorage.setItem('loginModalShown', 'true');
    }

    // Обработка отправки формы для логина
    $('#loginForm').on('submit', function(e) {
        e.preventDefault(); // Предотвращаем стандартное поведение формы
        const username = $('#username').val();
        const password = $('#password').val();
        const data = {
            username,
            password
        };

        $.ajax({
            url: `http://localhost:5295/api/Hrs/Login`,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function(response) {
                console.log('Успех:', response);
                alert('Успешный вход!');
                loadVacancyList(); // обновляем список после входа
                $('#loginModal').modal('hide'); // Закрываем модальное окно
            },
            error: function() {
                alert('Не удалось войти в систему');
            }
        });
    });

    // Загружаем список вакансий при загрузке страницы
    loadVacancyList();

    $('#addStudentForm').on('submit', function(e) {
        e.preventDefault();
        const applicant = $('#applicantId').val() === 'Yes'; // true или false
        const uniqueNumber = $('#id').val();

        $.ajax({
            url: `http://localhost:5295/api/Vacancies/${uniqueNumber}`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(applicant),
            success: function(response) {
                console.log('Успех:', response);
                alert('Вакансия изменена!');
                loadVacancyList(); // обновляем список после изменения
            },
            error: function() {
                alert('Не удалось изменить вакансию');
            }
        });
    });

    $('#closedInternshipsForm').on('submit', function(e) {
        e.preventDefault();
        const uniqueNumber = $('#closedInternshipsId').val();
        const internships = $('#internshipId').val() === 'Yes';

        $.ajax({
            url: `http://localhost:5295/api/Vacancies/${uniqueNumber}/Internships`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(internships),
            success: function() {
                alert('Стажировка закрыта');
                loadVacancyList(); // обновляем список после закрытия
            },
            error: function() {
                alert('Ошибка при закрытии стажировки');
            }
        });
    });

    $('#deleteVacancyForm').on('submit', function(e) {
        e.preventDefault();
        const uniqueNumber = $('#idDeleted').val();

        $.ajax({
            url: `http://localhost:5295/api/Vacancies/${uniqueNumber}`,
            type: 'DELETE',
            contentType: 'application/json',
            success: function() {
                alert('Вакансия закрыта');
                loadVacancyList(); // обновляем список после удаления
            },
            error: function() {
                alert('Ошибка при закрытии вакансии');
            }
        });
    });

    $('#sendTaskForm').on('submit', function(e) {
        e.preventDefault();
        const uniqueNumber = $('#sendUniqueNumber').val();

        $.ajax({
            url: `http://localhost:5295/api/Vacancies/${uniqueNumber}/Tasks`,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify({}), // возможно, нужно передать данные
            success: function() {
                alert('Задача отправлена');
                loadVacancyList(); // обновляем список после отправки
            },
            error: function() {
                alert('Ошибка при отправке');
            }
        });
    });

    function loadVacancyList() {
        $.ajax({
            url: 'http://localhost:5295/api/Vacancies',
            type: 'GET',
            success: function(data) {
                const studentList = $('#studentList tbody');
                studentList.empty();
                data.forEach(vacancy => {
                    const row = `<tr>
                        <td>${vacancy.id}</td>
                        <td>${vacancy.name}</td>
                        <td>${vacancy.description}</td>
                        <td>${vacancy.state}</td>
                        <td>${vacancy.task ? 'Да' : 'Нет'}</td>
			<td>${vacancy.applicant ? 'Да' : 'Нет'}</td>
                        <td>${vacancy.internship ? 'Да' : 'Нет'}</td>
                        <td>${vacancy.department}</td>
                    </tr>`;
                    studentList.append(row);
                });
            },
            error: function() {
                alert('Не удалось загрузить список вакансий');
            }
        });
    }
});