using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication;
using ToDoApplication.Models;

namespace ToDoLibrary.CControllers {
    public class ToDosController {
        private readonly AppDbContext _context;

        //default constructor
        public ToDosController() {
            _context = new AppDbContext();
        }

        //Get All 
        public async Task<IEnumerable<ToDo>> GetAll() {
            return await _context.ToDos.
                                        Include(x => x.Category)
                                                .ToListAsync();
        }

        //Get by Primary Key
        public async Task<ToDo> GetByPk(int id) {
            return await _context.ToDos.FindAsync(id);
        }

        //Insert / Create 

        public async Task<ToDo> Create(ToDo todo) {
            if (todo == null) {
                throw new Exception("Input cannot be null");
            }
            if (todo.Id != 0) {
                throw new Exception("Input must have Id set to zero");
            }
            _context.ToDos.Add(todo);
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Create Failed");
            }
            return todo;


            //Update / Change
            public async Task Change(ToDo todo) {
                if (todo == null) {
                    throw new Exception("Input cannot be null");
                }
                _context.Entry(todo).State = EntityState.Modified;
                var rowsAffected = await _context.SaveChangesAsync();
                if (rowsAffected != 1) {
                    throw new Exception("Input cannot be null");
                }
                if (todo.Id == 0) {
                    throw new Exception("Input must have Id greater than zero");
                }
                _context.Entry(todo).State = EntityState.Modified;
                var rowssAffected = await _context.SaveChangesAsync();
                    if (rowsAffected != 1) {
                    throw new Exception("Change Failed");
                    }
            }


            // Delete / Remove
            public async Task<ToDo> Remove(int id) {
                var td = await _context.ToDos.FindAsync(id);
                if(td == null) {
                    throw new Exception("Cannot be found");
                }
                _context.ToDos.Remove(todo);
                var rowsAffected = await _context.SaveChangesAsync();
                if (rowsAffected != 1) {
                    throw new Exception("Remove Failed");
                }
                return td;


            }



        }



    }




}
