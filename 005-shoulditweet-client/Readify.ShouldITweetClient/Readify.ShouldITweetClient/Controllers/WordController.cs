﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Readify.ShouldITweetClient.DAL;
using Readify.ShouldITweetClient.Models;

namespace Readify.ShouldITweetClient.Controllers
{
    public class WordController : ApiController
    {
        private WordContext db = new WordContext();

        // GET: api/Word
        public IQueryable<Word> GetWords()
        {
            return db.Words;
        }

        // GET: api/Word/5
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> GetWord(int id)
        {
            Word word = await db.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            return Ok(word);
        }

        // PUT: api/Word/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWord(int id, Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != word.WordID)
            {
                return BadRequest();
            }

            db.Entry(word).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Word
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> PostWord(Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Words.Add(word);
            await db.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Word/5
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> DeleteWord(int id)
        {
            Word word = await db.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            db.Words.Remove(word);
            await db.SaveChangesAsync();

            return Ok(word);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordExists(int id)
        {
            return db.Words.Count(e => e.WordID == id) > 0;
        }
    }
}